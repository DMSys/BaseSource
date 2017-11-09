using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DMSys.Systems.MultiLanguagePack
{
    [XmlRootAttribute("LanguagePack", Namespace = "")]
    public class LanguagePack
    {
        [XmlElement("LanguageName", typeof(System.String), IsNullable = false)]
        public string LanguageName = "";

        [XmlElement("TCollections", typeof(List<TranslateCollection>), IsNullable = false)]
        public List<TranslateCollection> TCollections = new List<TranslateCollection>();

        /// <summary>
        /// Дава колекцията, ако съществува
        /// </summary>
        public TranslateCollection GetCollection(string аOwner)
        {
            foreach (TranslateCollection tc in TCollections)
            {
                if (tc.TOwner == аOwner)
                { return tc; }
            }
            return null;
        }

        /// <summary>
        /// Освобождава заредените данни
        /// </summary>
        public void Clear()
        {
            LanguageName = "";
            //
            foreach (TranslateCollection tc in TCollections)
            { tc.Clear(); }
            TCollections.Clear();
        }
    }

    [XmlRootAttribute("TranslateCollection", Namespace = "")]
    public class TranslateCollection
    {
        [XmlElement("TOwner", typeof(System.String), IsNullable = false)]
        public string TOwner = "";

        [XmlElement("TItem", typeof(TranslateItem), IsNullable = false)]
        public TranslateItem TItem = new TranslateItem();
        
        [XmlElement("TItems", typeof(List<TranslateItem>), IsNullable = false)]
        private List<TranslateItem> _TItems = new List<TranslateItem>();
        public List<TranslateItem> TItems
        {
            get
            { return _TItems; }
            set
            { _TItems = value; }
        }
        
        [XmlElement("TranslateArea", typeof(List<TranslateAreaItem>), IsNullable = false)]
        public List<TranslateAreaItem> TranslateArea = new List<TranslateAreaItem>();

        /// <summary>
        /// Проверява дали съществува елемента
        /// </summary>
        public bool ItemExists(string aName)
        {
            foreach (TranslateItem ti in TItem.TItems)
            {
                if (ti.TName == aName)
                { return true; }
            }
            return false;
        }

        /// <summary>
        /// Добавя нов елемент
        /// </summary>
        public TranslateItem ItemAdd( string aName, string aText, Type aTType)
        {
            TranslateItem ti = new TranslateItem(aName, aText, aTType);
            TItem.TItems.Add(ti);
            return ti;
        }

        /// <summary>
        /// Дава елемента, ако съществува
        /// </summary>
        public TranslateItem GetItem(string аTName)
        {
            foreach (TranslateItem ti in TItem.TItems)
            {
                if (ti.TName == аTName)
                { return ti; }
            }
            return null;
        }

        /// <summary>
        /// Освобождава заредените данни
        /// </summary>
        public void Clear()
        {
            TOwner = "";
            //
            foreach (TranslateItem ti in TItem.TItems)
            { ti.Clear(); }
            TItem.TItems.Clear();
        }
    }

    [XmlRootAttribute("TranslateItem", Namespace = "")]
    public class TranslateItem
    {
        public TranslateItem()
        {
            TName = "";
            TText = "";
            TTextOrg = "";
            TType = "";
        }

        public TranslateItem(string aTName, string aTText, Type aTType)
        {
            TName = aTName;
            TText = aTText;
            TTextOrg = aTText;
            TType = aTType.ToString();
        }

        [XmlElement("TName", typeof(System.String), IsNullable = false)]
        public string TName = "";

        [XmlElement("TText", typeof(System.String), IsNullable = false)]
        public string TText = "";

        [XmlElement("TTextOrg", typeof(System.String), IsNullable = false)]
        public string TTextOrg = "";

        [XmlElement("TType", typeof(System.String), IsNullable = false)]
        public string TType = "";

        [XmlElement("TItems", typeof(List<TranslateItem>), IsNullable = false)]
        public List<TranslateItem> TItems = new List<TranslateItem>();

        /// <summary>
        /// Проверява дали съществува елемента
        /// </summary>
        public bool ItemExists(string aName)
        {
            foreach (TranslateItem ti in TItems)
            {
                if (ti.TName == aName)
                { return true; }
            }
            return false;
        }

        /// <summary>
        /// Добавя нов елемент
        /// </summary>
        public TranslateItem ItemAdd(string aName, string aText, Type aTType)
        {
            TranslateItem ti = new TranslateItem(aName, aText, aTType);
            TItems.Add(ti);
            return ti;
        }

        /// <summary>
        /// Дава елемента, ако съществува
        /// </summary>
        public TranslateItem GetItem(string аTName)
        {
            foreach (TranslateItem ti in TItems)
            {
                if (ti.TName == аTName)
                { return ti; }
            }
            return null;
        }

        /// <summary>
        /// Освобождава заредените данни
        /// </summary>
        public void Clear()
        {
            TName = "";
            TText = "";
            TTextOrg = "";
            TType = "";

            TItems.Clear();
        }
    }

    [XmlRootAttribute("TranslateAreaItem", Namespace = "")]
    public class TranslateAreaItem
    {
        public TranslateAreaItem()
        {
            TText = "";
            TTextOrg = "";
        }

        public TranslateAreaItem(string aTText)
        {
            TText = aTText;
            TTextOrg = aTText;
        }

        [XmlElement("TText", typeof(System.String), IsNullable = false)]
        public string TText = "";

        [XmlElement("TTextOrg", typeof(System.String), IsNullable = false)]
        public string TTextOrg = "";
    }
}
