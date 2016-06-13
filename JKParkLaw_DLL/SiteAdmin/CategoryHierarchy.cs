using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;

namespace SiteAdmin.CategoryHierarchy
{
    public class Common
    {
        private static CategoryCollection collection;

        private Common()
        {

        }

        /// <summary>
        /// Wraper around local data cache to retrieve just root categories from the collection
        /// </summary>
        /// <returns>CategoryCollection containing just categories with a parentId of "root"</returns>
        public static CategoryCollection GetRootCategories(int sectionID)
        {
            CategoryCollection rootCategories = new CategoryCollection();
            PopulateCategoryData(sectionID);
            if (GetCategoryData() != null)
            {
                foreach (Category category in GetCategoryData())
                {
                    if (category.ParentId == 0)
                        rootCategories.Add(category);
                }
            }

            return rootCategories;
        }

        public static void PopulateCategoryData(int sectionID)
        {
            if (sectionID > 0)
            {
                DataTable sectionTable = AdminSections.GetSection(sectionID);
                if (sectionTable.Rows.Count > 0)
                {
                    DataRow sectionRow = sectionTable.Rows[0];
                    string sectionName = sectionRow["CategoryName"].ToString(); //sectionRow["CategoryDesc"].ToString();

                    DataTable categoriesDataTable = AdminCategories.GetCategories(sectionID);
                    collection = new CategoryCollection();
                    collection.Add(new Category(sectionID, 0, sectionName));
                    foreach (DataRow categoryRow in categoriesDataTable.Rows)
                    {
                        collection.Add(new Category((int)categoryRow["CategoryID"], (int)categoryRow["ParentID"], categoryRow["CategoryName"].ToString()));
                    }
                }
            }
            else
            {
                DataTable categoriesDataTable = AdminCategories.GetCategories();
                collection = new CategoryCollection();
                foreach (DataRow categoryRow in categoriesDataTable.Rows)
                {
                    collection.Add(new Category((int)categoryRow["CategoryID"], (int)categoryRow["ParentID"], categoryRow["CategoryName"].ToString()));
                }
            }
        }

        /// <summary>
        /// Method to generate sample data for examples
        /// </summary>
        /// <returns>CategoryCollection containing computer store related categories.</returns>
        public static CategoryCollection GetCategoryData()
        {
            return collection;
        }

    }
    public class CategoryCollection : List<Category>, IHierarchicalEnumerable
    {

        public CategoryCollection()
            : base()
        {
        }

        #region IHierarchicalEnumerable Members

        public IHierarchyData GetHierarchyData(object enumeratedItem)
        {
            return enumeratedItem as IHierarchyData;
        }

        #endregion

    }

    public class Category : IHierarchyData
    {

        private int _categoryId;
        private int _parentId;
        private string _name;

        /// <summary>
        /// Unique identifier for the category
        /// </summary>
        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        /// <summary>
        /// Foreign key to the parent category
        /// </summary>
        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        /// <summary>
        /// Friendly description of the category
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Hide the default public constructor
        /// </summary>
        private Category()
        {
        }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="categoryId">Unique identifier for the category</param>
        /// <param name="parentId">Foreign key to the parent category</param>
        /// <param name="name">Friendly description of the category</param>
        public Category(int categoryId, int parentId, string name)
        {
            _categoryId = categoryId;
            _parentId = parentId;
            _name = name;
        }

        #region IHierarchyData Members

        public IHierarchicalEnumerable GetChildren()
        {
            CategoryCollection children = new CategoryCollection();

            // Loop through your local data and find any children
            foreach (Category category in Common.GetCategoryData())
            {
                if (category.ParentId == this.CategoryId)
                {
                    children.Add(category);
                }
            }
            return children;
        }

        public IHierarchyData GetParent()
        {
            // Loop through your local data and report back with the parent
            foreach (Category category in Common.GetCategoryData())
            {
                if (category.CategoryId == this.ParentId)
                    return category;
            }
            return null;
        }

        public bool HasChildren
        {
            get
            {
                CategoryCollection children = GetChildren() as CategoryCollection;
                return children.Count > 0;
            }
        }

        public object Item
        {
            get { return this; }
        }

        public string Path
        {
            get { return this.CategoryId.ToString(); }
        }

        public string Type
        {
            get { return this.GetType().ToString(); }
        }

        #endregion

        public override string ToString()
        {
            return this.Name;
        }

    }


    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class CategoryDataSource : HierarchicalDataSourceControl, IHierarchicalDataSource
    {
        public CategoryDataSource() : base() { }

        // Return a strongly typed view for the current data source control.
        private CategoryDataSourceView view = null;
        protected override HierarchicalDataSourceView GetHierarchicalView(string viewPath)
        {
            if (null == view)
            {
                view = new CategoryDataSourceView(viewPath);
            }
            return view;
        }

        // This can be used declaratively. To enable declarative use, 
        // override the default implementation of CreateControlCollection 
        // to return a ControlCollection that you can add to.
        protected override ControlCollection CreateControlCollection()
        {
            return new ControlCollection(this);
        }
    }

    public class CategoryDataSourceView : HierarchicalDataSourceView
    {

        private string _viewPath;
        public CategoryDataSourceView(string viewPath)
        {
            _viewPath = viewPath;
        }

        public override IHierarchicalEnumerable Select()
        {
            CategoryCollection collection = new CategoryCollection();
            foreach (Category category in Common.GetCategoryData())
            {
                if (category.ParentId == 0)
                    collection.Add(category);
            }

            return collection;
        }

    }
}
