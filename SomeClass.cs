using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winformZoomOut
{
    class SomeClass
    {
        private readonly Form1 form;
        public SomeClass(Form1 form)
        {
            this.form = form;
        }

        private void SomeMethodDoingStuffWithText()
        {
            string Console = form.Console;
            form.Console = "some name";
        }

        public string testReturnstring()
        {
            string Console = form.Console;
            form.Console += "some name "+ Environment.NewLine;
            return "ok";
        }

    }
}
