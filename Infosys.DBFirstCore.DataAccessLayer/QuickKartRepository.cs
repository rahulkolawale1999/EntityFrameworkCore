using Infosys.DBFirstCore.DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infosys.DBFirstCore.DataAccessLayer
{    public class QuickKartRepository
    {
        private readonly QuickKartDbContext context;
        public QuickKartRepository(QuickKartDbContext context)
        {
            this.context=context;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            categories=(from c in context.Categories orderby c.CategoryId select c).ToList();
            return categories;
        }

        public List<Product> GetProductOnCategoryId(byte categoryId)
        {
            List<Product> listOfProduct = new List<Product> ();
            try
            {
                listOfProduct = (from p in context.Products where p.CategoryId == categoryId orderby p.Price ascending select p).ToList();
            }
            catch (Exception)
            {

                listOfProduct = null;
            }
            return listOfProduct;
        }

        public Product FilterProduct(byte categoryId)
        {
            Product product=new Product();
           
                product = (from p in context.Products where p.CategoryId == categoryId orderby p.Price ascending select p).LastOrDefault();
            
            return product;
        }

        public List<Product> FilterProductUsingLike(string pattern)
        {
            List<Product> lstOfProduct = new List<Product>();
            try
            {
               lstOfProduct=(from p in context.Products where EF.Functions.Like(p.ProductName,pattern) select p).ToList();
            }
            catch (Exception)
            {
                lstOfProduct = null;
            }
            return lstOfProduct;
        }

        public List<User> GetAllUser()
        {
            List<User> lstOfUser = new List<User>();
            try
            {
                lstOfUser = (from u in context.Users select u).ToList();
            }
            catch (Exception)
            {

                lstOfUser=null;
            }
            return lstOfUser;
        }

        //public int AddCategoryDetailsUsingUSP(string categoryName,out byte categoryId) 
        //{ 
        //    categoryId=0;
        //    int noOfRowsaffected=0;
        //    int returnResult = 0;
        //    SqlParameter prmCategoryName= new SqlParameter("@CategoryName",categoryName);
        //    SqlParameter prmCategoryId = new SqlParameter("@CategoryId", System.Data.SqlDbType.TinyInt);
        //    prmCategoryId.Direction = System.Data.ParameterDirection.Output;
        //    SqlParameter prmReturnResult = new SqlParameter("@ReturnResult", System.Data.SqlDbType.Int);
        //    prmReturnResult.Direction = System.Data.ParameterDirection.Output;
        //    //prmCategoryName.ParameterName = "@CategoryName";
        //    //prmCategoryName.Value = categoryName;
        //    //prmCategoryName.SqlDbType = System.Data.SqlDbType.VarChar;
        //    //prmCategoryName.Size = 80;
        //    //prmCategoryName.Direction=System.Data.ParameterDirection.Input;
        //    try
        //    {
        //        noOfRowsaffected=context.Database.ExecuteSqlRaw("EXEC @ReturnResult=usp_AddCategory @CategoryName @CategoryId OUT", prmReturnResult, prmCategoryName, prmCategoryId);
        //        returnResult=Convert.ToInt32(prmReturnResult.Value);
        //        categoryId = Convert.ToByte(prmCategoryId.Value);
        //    }
        //    catch (Exception)
        //    {

        //        categoryId=0;
        //        noOfRowsaffected = -1;
        //        returnResult = -99;
        //    }
        //    return returnResult;
        //}

        public int AddCategoryDetailsUsingUSP(string categoryName, out byte categoryId)
        {
            categoryId = 0;
            int noOfRowsAffected = 0;
            int returnResult = 0;
            SqlParameter prmCategoryName = new SqlParameter("@CategoryName", categoryName);
            SqlParameter prmCategoryId = new SqlParameter("@CategoryId", System.Data.SqlDbType.TinyInt);
            prmCategoryId.Direction = System.Data.ParameterDirection.Output;
            SqlParameter prmReturnResult = new SqlParameter("@ReturnResult", System.Data.SqlDbType.Int);
            prmReturnResult.Direction = System.Data.ParameterDirection.Output;
            try
            {
                noOfRowsAffected = context.Database
                                .ExecuteSqlRaw("EXEC @ReturnResult = usp_AddCategory @CategoryName, @CategoryId OUT",
                                               prmReturnResult, prmCategoryName, prmCategoryId);
                returnResult = Convert.ToInt32(prmReturnResult.Value);

                categoryId = Convert.ToByte(prmCategoryId.Value);
            }
            catch (Exception)
            {
                categoryId = 0;
                noOfRowsAffected = -1;
                returnResult = -99;
            }
            return returnResult;
        }

    }
}
