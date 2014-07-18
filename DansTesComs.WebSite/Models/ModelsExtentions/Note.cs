using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DansTesComs.WebSite.Models
{

    [MetadataType(typeof(NoteMetaData))]
    public partial class Note
    {
        public NoteValue NoteValue { get { return (NoteValue) Value; } set { Value = (int) value; } }
    }

    public enum NoteValue
    {
        moins = -1,
        plus = 1,
    }

    public class NoteMetaData
    {
        [Range(-1,1)]
        public int Value { get; set; }
    }
}