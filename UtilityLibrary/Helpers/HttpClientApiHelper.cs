using System.Net.Http.Headers;
using System.Text.Json;

namespace UtilityLibrary.Helpers;

/// <summary>
/// Helper for requests with HttpClient
/// </summary>
public static class HttpClientApiHelper
{
    #region Properties
    private static readonly Lazy<HttpClient> LazyHttpClient = new Lazy<HttpClient>(CreateHttpClient);

    private static readonly Lazy<JsonSerializerOptions> LazyJsonSerializerOptions = new Lazy<JsonSerializerOptions>(CreateJsonSerializerOptions);
    #endregion

    #region Private Methods
    private static HttpClient CreateHttpClient()
    {
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:7288/");
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return httpClient;
    }

    private static JsonSerializerOptions CreateJsonSerializerOptions()
    {
        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
        return jsonSerializerOptions;
    }

    private static T? GetObjectResult<T>(HttpContent httpContent)
    {
        T? objectResult = (T?)JsonSerializer.Deserialize<T>(
            httpContent.ReadAsStringAsync().Result,
            LazyJsonSerializerOptions.Value
        );
        return objectResult;
    }

    #endregion

    #region Public Methods


    /// <summary>
    /// Get method request to a specific url
    /// </summary>
    /// <param name="requestUri">The specific URL of the request</param>
    /// <typeparam name="T">Generic type to deserialize JSON response</typeparam>
    /// <returns>Returns the parsed JSON in an object of type T</returns>
    public static T? Get<T>(string requestUri)
    {
        T? objectResult = default;
        try
        {
            Task<HttpResponseMessage> task = LazyHttpClient.Value.GetAsync(requestUri);

            if (task.Result is not null && task.Result.IsSuccessStatusCode)
            {
                objectResult = GetObjectResult<T>(task.Result.Content);
            }
        }
        catch (Exception ex)
        {
            //TODO: Add a fix for error cases
            _ = ex;
        }
        return objectResult;
    }

    public static T1? Create<T1, T2>(string requestUri, T2 data)
    {
        T1? objectResult = default;
        try
        {
            string serializeData = JsonSerializer.Serialize(data);

            Task<HttpResponseMessage> task = LazyHttpClient.Value.PostAsync(requestUri, new StringContent(serializeData, System.Text.Encoding.UTF8, "application/json"));

            if (task.Result is not null && task.Result.IsSuccessStatusCode)
            {
                objectResult = GetObjectResult<T1>(task.Result.Content);
            }
        }
        catch (Exception ex)
        {
            //TODO: Add a fix for error cases
            _ = ex;
        }
        return objectResult;
    }

    public static T1? Update<T1, T2>(string requestUri, T2 data)
    {
        T1? objectResult = default;
        try
        {
            string serializeData = JsonSerializer.Serialize(data);

            Task<HttpResponseMessage> task = LazyHttpClient.Value.PutAsync(requestUri, new StringContent(serializeData, System.Text.Encoding.UTF8, "application/json"));

            if (task.Result is not null && task.Result.IsSuccessStatusCode)
            {
                objectResult = GetObjectResult<T1>(task.Result.Content);
            }
        }
        catch (Exception ex)
        {
            //TODO: Add a fix for error cases
            _ = ex;
        }
        return objectResult;
    }

    public static T? Delete<T>(string requestUri)
    {
        T? objectResult = default;
        try
        {
            Task<HttpResponseMessage> task = LazyHttpClient.Value.DeleteAsync(requestUri);

            if (task.Result is not null && task.Result.IsSuccessStatusCode)
            {
                objectResult = GetObjectResult<T>(task.Result.Content);
            }
        }
        catch (Exception ex)
        {
            //TODO: Add a fix for error cases
            _ = ex;
        }
        return objectResult;
    }

    #endregion
}