using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Auth.Core.Common.Models
{
    public class FileCacheItem<TData>
    {
        #region Public Properties

        public DateTime AbsoluteExpiration { get; set; }
        public TData Data { get; set; }

        #endregion Public Properties

        #region Public Methods

        public static FileCacheItem<TData> FromJson(string json)
        {
            return JsonSerializer.Deserialize<FileCacheItem<TData>>(json);
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public override string ToString()
        {
            return ToJson();
        }
        #endregion

    }
}
