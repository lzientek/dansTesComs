using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DansTesComs.Core.Models
{

    [MetadataType(typeof(NoteMetaData))]
    public partial class Note
    {
        public NoteValue NoteValue { get { return (NoteValue) Value; } set { Value = (int) value; } }
    }

    public enum NoteValue
    {
        Moins = 0,
        Plus = 1,
    }

    public class NoteMetaData
    {
        [Range(0,1)]
        public int Value { get; set; }
    }
}