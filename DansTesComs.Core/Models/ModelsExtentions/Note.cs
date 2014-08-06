using System.ComponentModel.DataAnnotations;

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
        Signaler = 9,
    }

    public class NoteMetaData
    {
        [Range(0,1)]
        public int Value { get; set; }
    }
}