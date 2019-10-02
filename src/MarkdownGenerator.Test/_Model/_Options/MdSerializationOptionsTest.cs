using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdSerializationOptionsTest
    {
        public static IEnumerable<object[]> Properties()
        {
            foreach (var property in typeof(MdSerializationOptions).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                yield return new[] { property.Name };
            }
        }

        [Theory]
        [MemberData(nameof(Properties))]
        public void Properties_of_the_default_instance_cannot_be_modified(string propertyName)
        {
            // ARRANGE
            var instance = MdSerializationOptions.Default;

            var property = typeof(MdSerializationOptions).GetProperty(propertyName);

            var testValue = GetTestValue(property.PropertyType);

            // ACT / ASSERT
            var exception = Assert.Throws<TargetInvocationException>(() => property.SetMethod.Invoke(instance, new[] { testValue }));
            Assert.IsType<InvalidOperationException>(exception.InnerException);

            // exception message should indicate which property cannot be set
            Assert.Contains(propertyName, exception.InnerException.Message);
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

        private object GetTestValue(Type type)
        {
            if(!type.IsValueType)
            {
                return null;
            }

            var defaultValue = Activator.CreateInstance(type);
            if(type.IsEnum)
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

    }
}
