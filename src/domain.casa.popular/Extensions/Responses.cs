namespace domain.casa.popular.Extensions
{
    using System;
    using System.Dynamic;

    public static class Responses
    {
        #region Error
        
        public static string GetErrorResponse(string message)
            => (new { error = new { message = message } }).ToJson();

        public static string GetErrorResponse(string message, int statusCode)
            => (new { error = new { code = statusCode, message = message } }).ToJson();

        public static string GetErrorResponse(string message, string innerException)
            => (new { error = new { message = message, exception = innerException } }).ToJson();

        public static string GetErrorObjectResponse(string objectName, string objectResult)
        {
            var property = new ExpandoObject() as IDictionary<string, Object>;
            property.Add(objectName.ToLower(), objectResult);

            return property.ToJson();
        }

        public static string GetErrorNullResponse(string obj, string message)
            => (new { error = new { obj = obj, message = message } }).ToJson();

        #endregion Error

        #region Success

        public static string GetResponse(string message)
            => (new { message = message }).ToJson();

        public static string GetResponse(string objectName, object objectResult, string? message = null)
        {
            var response = new ExpandoObject() as IDictionary<string, object>;
            response.Add(objectName, objectResult);

            if (message != null)
                response.Add("message", message);

            return response.ToJson();
        }

        public static string GetCreatedResponse(string message)
            => (new { message = message }).ToJson();

        public static string GetCreatedResponse(string objectName, int id, string? message = null)
        {
            var response = new ExpandoObject() as IDictionary<string, object>;
            response.Add(objectName, id);

            if (message != null)
                response.Add("message", message);

            return response.ToJson();
        }

        public static string GetObjectResponse(string objectName, object objectResult)
        {
            var property = new ExpandoObject() as IDictionary<string, object>;
            property.Add(objectName.ToLower(), objectResult);

            return property.ToJson();
        }

        public static string GetObjectResponse(string objectName, object objectResult, int skip, int take, int totalRegisters = 0, int countRegisters = 0, string query = null)
        {
            var property = new ExpandoObject() as IDictionary<string, object>;

            var pages = (int)Math.Ceiling((decimal)totalRegisters / take);

            if (!string.IsNullOrEmpty(query))
                property.Add("queryExecuted", query);

            property.Add(objectName.ToLower(), objectResult);
            property.Add("nextpage", countRegisters > take ? $"?skip={skip + 1}&take={take}" : string.Empty);
            property.Add("previouspage", (skip - 1) <= 0 ? string.Empty : $"?skip={(skip - 1)}&take={take}");
            property.Add("pages", pages);
            property.Add("totalregisters", totalRegisters);
            return property.ToJson();
        }

        #endregion Success
    }
}