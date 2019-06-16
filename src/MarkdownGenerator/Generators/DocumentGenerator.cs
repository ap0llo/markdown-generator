using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Generators
{
    internal class EqualityComparerAdapter<T> : IEqualityComparer<object>
    {
        private readonly IEqualityComparer<T> m_InnerComparer;

        public EqualityComparerAdapter(IEqualityComparer<T> innerComparer)
        {
            m_InnerComparer = innerComparer;
        }

        public new bool Equals(object x, object y) => m_InnerComparer.Equals((T)x, (T)y);

        public int GetHashCode(object obj) => m_InnerComparer.GetHashCode((T)obj);
    }



    public class DocumentGenerator
    {
        private readonly Dictionary<Type, Action<object, DocumentGenerator>> m_Handlers = new Dictionary<Type, Action<object, DocumentGenerator>>();       
        private readonly Dictionary<Type, Dictionary<object, MdDocument>> m_Documents;

        public MdDocumentSet DocumentSet { get; }


        public DocumentGenerator() : this(new MdDocumentSet())
        { }

        public DocumentGenerator(MdDocumentSet documentSet)
        {
            DocumentSet = documentSet ?? throw new ArgumentNullException(nameof(documentSet));
        }


        public void AddHandler<T>(Action<T, DocumentGenerator> hander) => AddHandler(hander, EqualityComparer<T>.Default);
        
        public void AddHandler<T>(Action<T, DocumentGenerator> handler, IEqualityComparer<T> itemComparer)
        {
            //TODO: Check if handler for T already exists

            m_Handlers.Add(typeof(T), (object dataItem, DocumentGenerator mapper) => handler((T)dataItem, mapper));
            m_Documents.Add(typeof(T), new Dictionary<object, MdDocument>(new EqualityComparerAdapter<T>(itemComparer)));
        }


        public bool ContainsDocument<T>(T item)
        {
            //TODO: if there is no exact match for T, search is T is subtype of any known type

            if (!m_Documents.ContainsKey(typeof(T)))
                return false;

            return m_Documents[typeof(T)].ContainsKey(item);
        }


        public bool TryGetDocument<T>(T item, out MdDocument document)
        {
            throw new NotImplementedException();
        }



        public void RegisterDocument<T>(T item, string path, MdDocument document)
        {
            throw new NotImplementedException();
        }


        public void AddItem<T>(T item)
        {
            throw new NotImplementedException();
        }


        public MdSpan TryGetLink<T1, T2>(T1 from, T2 to, MdSpan linkText)
        {
            if(TryGetDocument(from, out var fromDoc) && TryGetDocument(to, out var toDoc))
            {
                return DocumentSet.GetLink(fromDoc, toDoc, linkText);
            }
            else
            {
                return linkText;
            }
        }


    }
}
