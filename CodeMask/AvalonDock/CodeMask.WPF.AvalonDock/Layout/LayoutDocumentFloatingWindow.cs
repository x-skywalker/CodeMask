﻿/************************************************************************

   AvalonDock

   




 


   

  **********************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Markup;

namespace CodeMask.WPF.AvalonDock.Layout
{
    [ContentProperty("RootDocument")]
    [Serializable]
    public class LayoutDocumentFloatingWindow : LayoutFloatingWindow
    {
        #region RootDocument

        private LayoutDocument _rootDocument;

        public LayoutDocument RootDocument
        {
            get { return _rootDocument; }
            set
            {
                if (_rootDocument != value)
                {
                    RaisePropertyChanging("RootDocument");
                    _rootDocument = value;
                    if (_rootDocument != null)
                        _rootDocument.Parent = this;
                    RaisePropertyChanged("RootDocument");

                    if (RootDocumentChanged != null)
                        RootDocumentChanged(this, EventArgs.Empty);
                }
            }
        }


        public event EventHandler RootDocumentChanged;

        #endregion

        public override IEnumerable<ILayoutElement> Children
        {
            get
            {
                if (RootDocument == null)
                    yield break;

                yield return RootDocument;
            }
        }

        public override void RemoveChild(ILayoutElement element)
        {
            Debug.Assert(element == RootDocument && element != null);
            RootDocument = null;
        }

        public override void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement)
        {
            Debug.Assert(oldElement == RootDocument && oldElement != null);
            RootDocument = newElement as LayoutDocument;
        }

        public override int ChildrenCount
        {
            get { return RootDocument != null ? 1 : 0; }
        }

        public override bool IsValid
        {
            get { return RootDocument != null; }
        }


#if TRACE
        public override void ConsoleDump(int tab)
        {
          System.Diagnostics.Trace.Write( new string( ' ', tab * 4 ) );
          System.Diagnostics.Trace.WriteLine( "FloatingDocumentWindow()" );

          RootDocument.ConsoleDump(tab + 1);
        }
#endif
    }
}