using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class TabuleiroExcption : Exception
    {
        public TabuleiroExcption (string msg) : base(msg)
        {

        }
    }
}
