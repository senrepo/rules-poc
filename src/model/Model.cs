using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace model
{
    public interface IModel
    {
        JToken Payload { get; }
        T GetJson<T>(string jsonPath);
        void SetJson<T>(string jsonPath, T value);

    }

    public class Model : IModel
    {
        private JToken _payload;

        public Model(string jsonPayload)
        {
            _payload = JToken.Parse(jsonPayload);
        }

        public JToken Payload
        {
            get
            {
                return _payload;
            }
        }

        public T GetJson<T>(string jsonPath)
        {
            Type _type = typeof(T);

            if(_type == typeof(int) || _type == typeof(string) || _type == typeof(double))  
                return (T)Convert.ChangeType( _payload.SelectToken(jsonPath), typeof(T));
            else 
                return JsonConvert.DeserializeObject<T>( _payload.SelectToken(jsonPath).ToString());
        }

        public void SetJson<T>(string jsonPath, T value)
        {
            //TODO: add a logic to create the element if not present

            var tokens =  _payload.SelectTokens(jsonPath).ToList();

            foreach (var val in tokens)
            {
                if (val == _payload)
                    _payload = JToken.FromObject(value);
                else
                    val.Replace(JToken.FromObject(value));
            }
        }

    }


}
