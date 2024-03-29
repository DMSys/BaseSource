﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.ComponentModel;

namespace NachoContent
{
    [ParseChildren(true)]
    [Designer(typeof(BlockDesigner))]
    public class Block : WebControl
    {
        private ITemplate _contentTemplate = null;

        private PlaceHolder _headerPlaceholder = null;
        private PlaceHolder _contentPlaceholder = null;

        private string _caption;

        public string Caption
        {
            get { return _caption; }

            set { _caption = value; }
        }

        [Browsable(false)]
        [TemplateContainer(typeof(TemplateContainer))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ITemplate ContentTemplate
        {
            get { return _contentTemplate; }
            set { _contentTemplate = value; }
        }

        public PlaceHolder HeaderPlaceholder
        {
            get { return _headerPlaceholder; }
            set { _headerPlaceholder = value; }
        }

        public PlaceHolder ContentPlaceholder
        {
            get { return _contentPlaceholder; }
            set { _contentPlaceholder = value; }
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();

            Control blockMarkup = Page.LoadControl("~/Design/Block.ascx");

            _headerPlaceholder = blockMarkup.FindControl("HeaderPlaceholder") as PlaceHolder;
            _contentPlaceholder = blockMarkup.FindControl("ContentPlaceholder") as PlaceHolder;

            _headerPlaceholder.Visible = ! String.IsNullOrEmpty(_caption);

            if (_headerPlaceholder.Visible)
            {
                Literal caption = new Literal();
                caption.Text = _caption;
                _headerPlaceholder.Controls.Add(caption);
            }

            if (_contentTemplate != null)
            {
                TemplateContainer container = new TemplateContainer();
                _contentTemplate.InstantiateIn(container);
                _contentPlaceholder.Controls.Add(container);
            }

            Controls.Add(blockMarkup);
        }

        public override void DataBind()
        {
            EnsureChildControls();
            base.DataBind();
        }

        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }

        public class TemplateContainer : Control, INamingContainer
        {
        }
    }

    public class BlockDesigner : ContainerControlDesigner
    {
        public override string FrameCaption
        {
            get
            {
                Block ctl = this.Component as Block;
                return ctl.Caption;
            }
        }
    }
}