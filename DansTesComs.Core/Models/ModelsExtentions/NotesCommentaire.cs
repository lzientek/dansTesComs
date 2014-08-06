using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DansTesComs.Core.Models
{
    public partial class NotesCommentaire
    {
        public NoteValue NoteValue { get { return (NoteValue)Value; } set { Value = (int)value; } }
    }
}
