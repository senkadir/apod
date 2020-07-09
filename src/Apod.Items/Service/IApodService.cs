using Apod.Items.Models;
using RestEase;
using System.Threading.Tasks;

namespace Apod.Items.Service
{
    public interface IApodService
    {
        [Get("")]
        Task<ApodModel> GetTodayAsync([Query(Name = "api_key")] string key);

    }
}
