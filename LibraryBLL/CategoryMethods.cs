using LibraryBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBLL
{
    public class CategoryMethods
    {
        public AccessMethods access;
        public CategoryMethods()
        {
            access = new AccessMethods();
        }
        public void CreateCategories(String sessName, String[] names)
        {
            
            var query = access.GetSessionByName(sessName);
            Session session = new Session();
            foreach (Session sess in query)
                session = sess;
            ICollection<Category> listCat = new HashSet<Category>();
            for (int i = 0; i < names.Length; i++)
            {
                Category cat = new Category(access.FindCategoryLastId() + i, names[i], (session.Range / names.Length) * i);
                listCat.Add(cat);
                session.Categories.Add(cat);
            }
            access.SaveCategories(listCat);
        }
    }
}