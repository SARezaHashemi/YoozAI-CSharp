using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoozAI
{
    public class YoozHandler : IDisposable
    {
        private string _pattern = string.Empty; 


        /// <summary>
        /// This is a yooz pattern
        /// Defult Value is String.Empty and throws NullReferenceException When you invoke <see cref="GetResponse(string)"/>
        /// </summary>
        public string Pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
        }


        /// <summary>
        /// Creates a new instant of yooz handlr
        /// </summary>
        /// <param name="pattern">assigns to <see cref="Pattern"/></param>
        public YoozHandler(string pattern)
        {
            Pattern = pattern;
        }


        /// <summary>
        /// Input a yooz pattern and give a response from that
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>response of the request</returns>
        /// <exception cref="NullReferenceException">when pattern is null or whiteSpace</exception>
        public string GetResponse(string request)
        {
            // because pattern request has it too
            request += "\n\r";

            if(String.IsNullOrWhiteSpace(_pattern))
            {
                throw new NullReferenceException($"{nameof(_pattern)} is empty");
            }

            var blocks =YoozBlock.GetBlocks(_pattern);

            var response = blocks.FirstOrDefault(b => b.Request.Trim() == request.Trim());

            if (response is null)
            {
                return "Not found";
            }
            return response.Response;
        }

        public void Dispose()
        {
            this._pattern = "";
            this.Pattern = "";
        }
    }
}
