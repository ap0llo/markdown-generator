using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdSerializationOptionsTest
    {
        private object GetTestValue(Type type)
        {
            if (!type.IsValueType)
            {
                return null;
            }

            var defaultValue = Activator.CreateInstance(type);
            if (type.IsEnum)
            {
                var values = Enum.GetValues(type);
                if (values.Length <= 1)
                    return defaultValue;
                else
                    return values.Cast<object>().First(x => !x.Equals(defaultValue));
            }
            else
            {
                return defaultValue;
            }
        }

        public static IEnumerable<object[]> DefaultInstancesAndProperties()
        {
            foreach (var property in typeof(MdSerializationOptions).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                yield return new object[] { MdSerializationOptions.Default, property.Name };
                foreach(var presetField in typeof(MdSerializationOptions.Presets).GetFields(BindingFlags.Static | BindingFlags.Public))
                {
                    yield return new object[] { presetField.GetValue(null), property.Name };
                }
            }            
        }

        [Theory]
        [MemberData(nameof(DefaultInstancesAndProperties))]
        public void Properties_of_the_default_instances_cannot_be_modified(MdSerializationOptions instance, string propertyName)
        {
            // ARRANGE
            var property = typeof(MdSerializationOptions).GetProperty(propertyName);

            var testValue = GetTestValue(property.PropertyType);

            // ACT / ASSERT
            var exception = Assert.Throws<TargetInvocationException>(() => property.SetMethod.Invoke(instance, new[] { testValue }));
            Assert.IsType<InvalidOperationException>(exception.InnerException);

            // exception message should indicate which property cannot be set
            Assert.Contains(propertyName, exception.InnerException.Message);
        }

        public static IEnumerable<object[]> Properties()
        {
            foreach (var property in typeof(MdSerializationOptions).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                yield return new object[] { property.Name };
            }
        }

        [Theory]
        [MemberData(nameof(Properties))]
        public void Properties_of_non_default_instance_can_be_modified(string propertyName)
        {
            // ARRANGE
            var instance = new MdSerializationOptions();

            var property = typeof(MdSerializationOptions).GetProperty(propertyName);

            var newValue = GetTestValue(property.PropertyType);

            // ACT / ASSERT
            property.SetMethod.Invoke(instance, new[] { newValue });
            var actualValue = property.GetMethod.Invoke(instance, Array.Empty<object>());
            Assert.Equal(newValue, actualValue);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-5)]
        public void ListIndentationWidth_throws_ArgumentOutOfRangeException_when_set_to_a_negative_value(int value)
        {
            var instance = new MdSerializationOptions();
            Assert.Throws<ArgumentOutOfRangeException>(() => instance.MinimumListIndentationWidth = value);
        }

        [Fact]
        public void Presets_get_throws_PresetNotFoundException_for_unknown_preset_name()
        {
            Assert.Throws<PresetNotFoundException>(() => MdSerializationOptions.Presets.Get("Some unknown preset name"));
        }

        [Fact]
        public void Default_Preset_is_the_default_MdSerializationOptions_instance()
        {
            Assert.Same(MdSerializationOptions.Default, MdSerializationOptions.Presets.Default);
        }


        public static IEnumerable<object[]> PresetInstancesAndNames()
        {
            foreach (var presetField in typeof(MdSerializationOptions.Presets).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                yield return new object[] { presetField.GetValue(null), presetField.Name };
            }
        }

        [Theory]
        [MemberData(nameof(PresetInstancesAndNames))]
        public void Presets_get_returns_expected_preset(MdSerializationOptions preset, string presetName)
        {
            Assert.Same(preset, MdSerializationOptions.Presets.Get(presetName));
            Assert.Same(preset, MdSerializationOptions.Presets.Get(presetName.ToLower()));
            Assert.Same(preset, MdSerializationOptions.Presets.Get(presetName.ToUpper()));
        }


        [Fact]
        public void MkDocs_preset_has_expected_settings()
        {
            var sut = MdSerializationOptions.Presets.MkDocs;

            Assert.Equal(4, sut.MinimumListIndentationWidth);
            Assert.IsType<MkDocsTextFormatter>(sut.TextFormatter);
        }
    }
}
