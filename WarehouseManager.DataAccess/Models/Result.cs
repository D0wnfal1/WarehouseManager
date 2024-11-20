using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.DataAccess.Models
{
	public class Result
	{
		public bool IsSuccess { get; }
		public string ErrorMessage { get; }

		private Result(bool isSuccess, string errorMessage = null)
		{
			IsSuccess = isSuccess;
			ErrorMessage = errorMessage;
		}

		public static Result Success()
		{
			return new Result(true);
		}

		public static Result Failure(string errorMessage)
		{
			return new Result(false, errorMessage);
		}
	}

}
