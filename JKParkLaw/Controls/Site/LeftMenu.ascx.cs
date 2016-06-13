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

namespace JKParkLaw.Controls.Site
{
    public partial class LeftMenu : System.Web.UI.UserControl
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        private int _curentCategoryID;
        private int _curentSectionID;
        private TreeNode _currentNode = null;
        private TreeView CategoriesTV;
        SiteFrontend.CategoryHierarchy.CategoryCollection collection
            = SiteFrontend.CategoryHierarchy.Common.GetRootCategories(0);

        protected void Page_Load(object sender, EventArgs e)
        {
            MakeCategoriesTree();
        }

        public int CurentCategoryID
        {
            set { _curentCategoryID = value; }
            get { return _curentCategoryID; }
        }

        public string StylePath
        {
            get { return ((JKParkLaw.Front)Page.Master).StylePath; }
        }

        private void MakeCategoriesTree()
        {
            TreeNode newNode;
            CategoriesTV = new TreeView();
            CategoriesTV.Nodes.Clear();

            //Fill Categories Tree View
            foreach (SiteFrontend.CategoryHierarchy.Category cat in collection)
            {
                newNode = new TreeNode(cat.Name);
                newNode.NavigateUrl = cat.NavigateURL;
                newNode.Value = cat.CategoryId.ToString();
                if (cat.HasChildren)
                {
                    //logger.Debug("# SetNodes 1 - "+cat.Name);
                    SetNodes(cat, ref newNode);
                }
                if (_curentCategoryID == cat.CategoryId)
                {
                    _curentSectionID = cat.SectionId;
                    _currentNode = newNode;
                }
                CategoriesTV.Nodes.Add(newNode);
            }

            //debug
            if (_currentNode != null)
            {
                //logger.Debug("# _currentNode - " + _currentNode.Value);
                //logger.Debug("# _curentCategoryID - " + _curentCategoryID.ToString());

                ExpandNodesInPaths(_currentNode);
                ExpandChildrenNodesInPaths(_currentNode);
                ExpandSiblingNodesInPaths(_currentNode);
                _currentNode.Expand();
                _currentNode.Select();
            }
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
                //debug
                //logger.Debug("# HasChildren - " + child.Name);
                if (child.HasChildren)
                {
                    SetNodes(child, ref childNode);
                }
                if (_curentCategoryID == child.CategoryId)
                {
                    _curentSectionID = child.SectionId;
                    _currentNode = childNode;
                }
                addInNode.ChildNodes.Add(childNode);
            }
        }

        public void ExpandNodesInPaths(TreeNode node)
        {
            node.Expand();
            if (node.Parent != null)
            {
                ExpandNodesInPaths(node.Parent);
            }
        }

        public void ExpandChildrenNodesInPaths(TreeNode node)
        {
            foreach (TreeNode child in node.ChildNodes)
            {
                child.Expand();
            }
        }

        public void ExpandSiblingNodesInPaths(TreeNode node)
        {
            if (node.Parent != null)
            {
                foreach (TreeNode child in node.Parent.ChildNodes)
                {
                    child.Expand();
                }
            }
        }

        private void GetCategoryIDNode(TreeNodeCollection nodes, string categoryID)
        {
            foreach (TreeNode node in nodes)
            {
                Response.Write(string.Format("{0} = {1} = {2}<br />", node.Text, node.DataPath));
                GetCategoryIDNode(node.ChildNodes, categoryID);
            }

        }

        private void MakeHTMLTree()
        {

            LiteralControl literalControl;

            foreach (TreeNode node in CategoriesTV.Nodes)
            {
                //logger.Debug("# _node - " + node.Value + "   " + _curentCategoryID.ToString());
                if (node.Value == _curentCategoryID.ToString() || node.Value == _curentSectionID.ToString())
                {
                    literalControl = new LiteralControl(String.Format("<li class='current'><a href='{0}'>{1}</a></li>\n", node.NavigateUrl, node.Text));
                }
                else
                {
                    literalControl = new LiteralControl(String.Format("<li><a href='{0}'>{1}</a></li>\n", node.NavigateUrl, node.Text));
                }
                CategoriesPlaceHolder.Controls.Add(literalControl);

                if (node.ChildNodes.Count > 0)
                {
                    SetHTMLNodes(node);
                }
            }

        }


        private void SetHTMLNodes(TreeNode node)
        {
            string controlContent;
            int count = 0;
            int childCount = node.ChildNodes.Count;
            string startControl ="";

            foreach (TreeNode childNode in node.ChildNodes)
            {
                //If is the selected cateogory then hs the catLevelSelected class
                if (_currentNode == childNode)
                {
                    if (childNode.ChildNodes.Count == 0)
                    {
                        controlContent = String.Format(
                        "<li><a href='{0}' class='on'>{1}</a></li>\n",
                        childNode.NavigateUrl, childNode.Text, childNode.Depth);
                    }
                    else
                    {
                        controlContent = String.Format(
                        "<li><a href='{0}' class='on'>{1}</a></li>\n",
                        childNode.NavigateUrl, childNode.Text, childNode.Depth);
                    }
                }
                else
                {
                    //get the img 
                    if (childNode.Expanded == true)
                    {
                        if (childNode.ChildNodes.Count == 0)
                        {
                            controlContent = String.Format(
                            "<li><a href='{0}'>{1}</a></li>\n",
                            childNode.NavigateUrl, childNode.Text, childNode.Depth);
                        }
                        else
                        {
                            controlContent = String.Format(
                            "<li><a href='{0}'>{1}</a></li>\n",
                            childNode.NavigateUrl, childNode.Text, childNode.Depth);
                        }
                    }
                    else
                    {
                        //controlContent = String.Format(
                        //"<li><a href='{0}'>{1}</a></li>",
                        //childNode.NavigateUrl, childNode.Text, childNode.Depth);
                        controlContent = "";
                    }
                }

                if (count == 0 && string.IsNullOrEmpty(controlContent) == false)
                {
                    startControl = "<ul class='subcat'>\n";
                    CategoriesPlaceHolder.Controls.Add(new LiteralControl(startControl));
                }
                CategoriesPlaceHolder.Controls.Add(new LiteralControl(controlContent));


                if (childNode.Expanded == true)
                {
                    SetHTMLNodes(childNode);
                }

                count += 1;
            }

            if (string.IsNullOrEmpty(startControl) == false)
            {
                CategoriesPlaceHolder.Controls.Add(new LiteralControl("</ul>\n"));
            }
        }

    }
}