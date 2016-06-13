using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Linq;
using NLog;
using SiteFrontend;

namespace JKParkLaw.Controls.Categories
{
    public partial class CategoryListing : System.Web.UI.UserControl
    {

        protected int _categoryID;
        protected string _categoryName;
        protected int _sectionID;
        protected string _sectionName;


        private TreeNode _currentNode = null;
        private TreeView CategoriesTV;
        SiteFrontend.CategoryHierarchy.CategoryCollection collection;

        private DataTable ContentsTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            _categoryID = ((JKParkLaw.Categories.Category)this.Page).CategoryID;
            _categoryName = ((JKParkLaw.Categories.Category)this.Page).CategoryName;
            _sectionID = ((JKParkLaw.Categories.Category)this.Page).SectionID;
            _sectionName = ((JKParkLaw.Categories.Category)this.Page).SectionName;

            collection = SiteFrontend.CategoryHierarchy.Common.GetRootCategories(_sectionID);

            ContentsTable = SiteFrontend.FrontContents.GetContents(_categoryID);

            MakeCategoriesTree();
        }

        private void MakeCategoriesTree()
        {
            TreeNode newNode;
            CategoriesTV = new TreeView();
            CategoriesTV.Nodes.Clear();

            //Fill Categories Tree View
            foreach (SiteFrontend.CategoryHierarchy.Category cat in collection)
            {
                //logger.Debug("# category name - " + cat.Name);
                newNode = new TreeNode(cat.Name);
                newNode.NavigateUrl = cat.NavigateURL;
                newNode.Value = cat.CategoryId.ToString();
                if (cat.HasChildren)
                {
                    SetNodes(cat, ref newNode);
                }

                //if (_categoryID == cat.CategoryId)
                //{
                //    _sectionID = cat.SectionId;
                //    _currentNode = newNode;
                //}
                CategoriesTV.Nodes.Add(newNode);
            }

            if (collection.Count == 1)
                MakeHTMLTree();
        }

        private void SetNodes(SiteFrontend.CategoryHierarchy.Category cat, ref TreeNode addInNode)
        {
            TreeNode childNode;
            SiteFrontend.CategoryHierarchy.CategoryCollection childrens = cat.GetChildren() as
                SiteFrontend.CategoryHierarchy.CategoryCollection;

            foreach (SiteFrontend.CategoryHierarchy.Category child in childrens)
            {
                childNode = new TreeNode(child.Name);
                childNode.NavigateUrl = child.NavigateURL;
                childNode.Value = child.CategoryId.ToString();
                //if (child.HasChildren)
                //{
                //    SetNodes(child, ref childNode);
                //}
                if (_categoryID == child.CategoryId)
                {
                    _currentNode = childNode;
                }
                addInNode.ChildNodes.Add(childNode);
            }
        }

        private void MakeHTMLTree()
        {
            LiteralControl literalControl;
            foreach (TreeNode child in CategoriesTV.Nodes[0].ChildNodes)
            {
                if (child.Value == _categoryID.ToString())
                {
                    literalControl = new LiteralControl(String.Format("<li class='current'><a href='{0}'>{1}</a></li>\n", child.NavigateUrl, child.Text));
                }
                else
                {
                    literalControl = new LiteralControl(String.Format("<li><a href='{0}'>{1}</a></li>\n", child.NavigateUrl, child.Text));
                }
                CategoriesPlaceHolder.Controls.Add(literalControl);
            }
        }

    }
}