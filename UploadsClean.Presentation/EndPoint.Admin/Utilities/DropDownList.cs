using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Policy;
using UploadsClean.Common;

namespace EndPoint.Admin.Utilities
{
    public static class DropDownList
    {
        public static List<SelectListItem> Execute(Request request, object List)
        {
            var items = new List<SelectListItem>();
            //switch (request)
            //{
            //    case Request.category:

            //        foreach (CategoryDtoForList item in (List<CategoryDtoForList>) List)
            //        {

            //            items.Add(new SelectListItem()
            //            {
            //                Value = item.Id.ToString(),
            //                Text = item.Title,

            //            });
            //        }
            //        items.Insert(0, new SelectListItem() { Value = "0", Text = "لطفا دسته بندی مربوط به این کالا را انتخاب کنید" });
            //        return items;

            //    case Request.DisCount:

            //        foreach (DiscountDtoLists item in (List<DiscountDtoLists>)List)
            //        {

            //            items.Add(new SelectListItem()
            //            {
            //                Value=item.Id.ToString(),
            //                Text= item.Title,   

            //            });
            //        }

            //        items.Insert(0, new SelectListItem { Value = "0", Text = "تخفیف مورد نظر خود را وارد کنید" });
                    
            //        return items;

               // default:

                return new List<SelectListItem>();



            }

        }



    }


