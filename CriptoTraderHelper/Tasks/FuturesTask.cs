using CriptoTraderHelper.Strategies;
using CriptoTraderHelper.Tools;
using MexcApi;
using MexcApi.Api;
using MexcApi.Responses.Futures;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CriptoTraderHelper.Tasks
{
    public class FuturesTask
    {
        public FuturesTask()
        {
            _api = new MexcAPI();
        }

        public int TimeDelay = 300000;
        private readonly MexcAPI _api;
        public async Task ExecuteAsync()
        {
            Console.Clear();
             List<FuturesContractDetail> contracts = await _api.FuturesApi.ContractDetail();

             foreach (var contract in contracts)
             {
                 StrategyRsiAndChange strategyRsiAndChange = new StrategyRsiAndChange();
                 await strategyRsiAndChange.ExecuteAsync(contract);
             }

            await Task.Delay(TimeDelay);
        }
    }
}
