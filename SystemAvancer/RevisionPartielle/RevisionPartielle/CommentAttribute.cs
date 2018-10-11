using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionPartielle
{
    class CommentAttribute : Attribute
    {
        string comment;
        public CommentAttribute(string comment)
        {
            this.comment = comment;
        }

        public CommentAttribute()
        {

        }
    }
}
