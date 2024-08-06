namespace CriptoBrokerViewer.Api
{
    public sealed class MexcApi
    {
        public MexcApi() 
        {
            SpotV3 = new MexcSpotApiV3();
            SpotV2 = new MexcApiSpotV2();
            Futures = new MexcApiFutures();
        }
        public MexcSpotApiV3 SpotV3;
        public MexcApiSpotV2 SpotV2;
        public MexcApiFutures Futures;
    }
}
