using PubsMartes.Web.Responses.Core;

namespace PubsMartes.Web.ViewModels.ControllerService
{
    public class IWebService
    {
        public BaseResponse<T> GetData<T>(string URL);
        public T PostData<T>(string URL, object model);
    }
}
