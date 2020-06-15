using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace GasPump
{
    public class PumpUsageHistory
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("gasWithdrawAmount")]
        public decimal GasWithdrawAmount { get; set; }
        [JsonPropertyName("withdrawDate")]
        public DateTime WithdrawDate { get; set; }
        [JsonPropertyName("remainingGasInPump")]
        public decimal RemainingGasInPump { get; set; }
    }
}
