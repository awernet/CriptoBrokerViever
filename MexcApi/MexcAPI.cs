using MexcApi.Api;

namespace MexcApi
{
    public class MexcAPI
    {
        public MexcAPI() 
        {
            SpotV3Api = new SpotV3Api();
            SpotV2Api = new SpotV2Api();
            FuturesApi = new FuturesApi();
        }

        public SpotV3Api SpotV3Api;
        public SpotV2Api SpotV2Api;
        public FuturesApi FuturesApi;

    }
}
