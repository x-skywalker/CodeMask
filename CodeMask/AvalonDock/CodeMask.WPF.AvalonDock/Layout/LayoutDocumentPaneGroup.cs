﻿/************************************************************************

   AvalonDock

   




 


   

  **********************************************************************/

using System;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace CodeMask.WPF.AvalonDock.Layout
{
    [ContentProperty("Children")]
    [Serializable]
    public class LayoutDocumentPaneGroup : LayoutPositionableGroup<ILayoutDocumentPane>, ILayoutDocumentPane,
        ILayoutOrientableGroup
    {
        public LayoutDocumentPaneGroup()
        {
        }

        public LayoutDocumentPaneGroup(LayoutDocumentPane documentPane)
        {
            Children.Add(documentPane);
        }

        #region Orientation

        private Orientation _orientation;

        public Orientation Orientation
        {
            get { return _orientation; }
            set
            {
                if (_orientation != value)
                {
                    RaisePropertyChanging("Orientation");
                    _orientation = value;
                    RaisePropertyChanged("Orientation");
                }
            }
        }

        #endregion

        protected override bool GetVisibility()
        {
            return true;
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Orientation", Orientation.ToString());
            base.WriteXml(writer);
        }

        public override void ReadXml(XmlReader reader)
        {
            if (reader.MoveToAttribute("Orientation"))
                Orientation = (Orientation) Enum.Parse(typeof (Orientation), reader.Value, true);
            base.ReadXml(reader);
        }

#if TRACE
        public override void ConsoleDump(int tab)
        {
          System.Diagnostics.Trace.Write( new string( ' ', tab * 4 ) );
          System.Diagnostics.Trace.WriteLine( string.Format( "DocumentPaneGroup({0})", Orientation ) );

          foreach (LayoutElement child in Children)
              child.ConsoleDump(tab + 1);
        }
#endif
    }
}