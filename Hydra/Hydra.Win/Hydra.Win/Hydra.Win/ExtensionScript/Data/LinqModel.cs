using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Hydra.Win.ExtensionScript.Data
{
    [DataContract]
    public class LinqConnectionModel
    {
        /// <summary>
        /// Тип на базата
        /// </summary>
        [DataMember]
        public string database { get; set; }

        /// <summary>
        /// Connection String
        /// </summary>
        [DataMember]
        public string connection { get; set; }
    }

    [DataContract]
    public class LinqQueryModel
    {
        [DataMember]
        public string command { get; set; }

        [DataMember]
        public List<LinqTableFieldModel> list { get; set; }

        [DataMember]
        public List<LinqTableModel> from { get; set; }

        [DataMember]
        public List<LinqConditionModel> where { get; set; }
    }

    [DataContract]
    public class LinqTableModel
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string alias { get; set; }
    }

    [DataContract]
    public class LinqTableFieldModel
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string alias { get; set; }

        [DataMember]
        public string text { get; set; }
    }

    [DataContract]
    public class LinqConditionModel
    {
        [DataMember]
        public string condition { get; set; }

        [DataMember]
        public LinqTableFieldModel expr1 { get; set; }

        [DataMember]
        public LinqTableFieldModel expr2 { get; set; }
    }
}
