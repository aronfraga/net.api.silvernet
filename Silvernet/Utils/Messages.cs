namespace Silvernet.Utils {
	public class Messages {

		public const string CREATED           = "created succesfully!";
		public const string UPDATED           = "updated succesfully!";
		public const string DELETED           = "deleted succesfully!";
		public const string MOD_INCORRECT     = "The object model is not correct";
		public const string NO_TOKEN          = "To list by name, first log in";
		public const string SOME_WRONG        = "Something went wrong";

		public const string USER_EXIST        = "The username or email is already in the database";
		public const string USER_USRN_PASSW   = "User or Password are incorrect";
		public const string USER_BY_PARAMS    = "The user id passed by params cannot be empty or null";

		public const string CAT_NOT_NULL      = "The category cannot be empty or null";
		public const string CAT_EXIST         = "The category is already in the database";
		public const string CAT_ID_NOT_NULL   = "The category id cannot be empty or null";
		public const string CAT_NOT_EXIST     = "The category does not exist";
		public const string CAT_BY_PARAMS     = "The category id passed by params cannot be empty or null";
		public const string CAT_SAME_NAME     = "Category with the same name already exists";

		public const string PRO_NOT_NULL      = "The product cannot be empty or null";
		public const string PRO_EXIST         = "The product is already in the database";
		public const string PRO_ID_NOT_NULL   = "The product id cannot be empty or null";
		public const string PRO_NOT_EXIST     = "The product does not exist or id is not correct";
		public const string PRO_BY_PARAMS     = "The product id passed by params cannot be empty or null";

		public const string SHOC_NOT_NULL     = "The product id and quantity cannot be empty or null";
		public const string SHOC_EXIST        = "The shopping cart is already in the database";
		public const string SHOC_ID_NOT_NULL  = "The shopping cart id cannot be empty or null";
		public const string SHOC_NOT_EXIST    = "The shopping cart does not exist or id is not correct";
		public const string SHOC_NOT_EXIST_OR = "The shopping cart does not exist or cannot be deleted";
		public const string SHOC_BY_PARAMS    = "The shopping cart id passed by params cannot be empty or null";
		public const string SHOC_NOT_STOCK	  = "The quantity selected is higher than stock of product";

		public const string ORDER_BY_PARAMS   = "The order id passed by params cannot be empty or null";
		public const string ORDER_NOT_EXIST   = "The order does not exist or id is not correct";
		public const string ORDER_NO_ORDER    = "There are not pending orders for the user";

		public const string USER_MOD_USERNAME = "The username must be obligatory and must be a string";
		public const string USER_MOD_EMAIL    = "The email must be obligatory and must be a string";
		public const string USER_MOD_PASSWORD = "The password must be obligatory and must be a string";

		public const string SHOC_MOD_ID       = "The Id of shopping cart must be obligatory and must be an integer";
		public const string SHOC_MOD_PROID    = "The productId must be obligatory and must be an integer";
		public const string SHOC_MOD_QTY      = "The quantity must be obligatory and must be an integer";

		public const string PRO_MOD_ID        = "The id of product must be obligatory and must be an integer";
		public const string PRO_MOD_BRAND     = "The brand of product must be obligatory and must be a string";
		public const string PRO_MOD_MODEL     = "The model of product must be obligatory and must be a string";
		public const string PRO_MOD_CATEG     = "The category id of product must be obligatory and must be a string";
		public const string PRO_MOD_PRICE     = "The price must be obligatory and must be a double";
		public const string PRO_MOD_STOCK     = "The Stock must be obligatory and must be an integer";

		public const string CAT_MOD_NAME      = "The name must be obligatory and must be a string";

	}
}
