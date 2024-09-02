using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoozAI
{
    public class YoozBlock
    {
        public string Request { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;

        public YoozBlock()
        {
            //Without parameter constructor
        }
        public YoozBlock(string request, string response)
        {
            Request = request;
            Response = response;
        }
        public override string ToString()
        {
            return (@$"
(
+ {Request}
- {Response}
)
");
        }
        /// <summary>
        /// Get All Blocks in a pattern
        /// </summary>
        /// <param name="yoozBlock">pattern</param>
        /// <returns>a generic list of <see cref="YoozBlock"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<YoozBlock> GetBlocks(string yoozBlock)
        {
            Console.WriteLine("I Am thinking in first part of GetBlock");

            List<YoozBlock> blocks = new List<YoozBlock>();
            if (string.IsNullOrEmpty(yoozBlock))
            {
                throw new ArgumentException($"{nameof(yoozBlock)} is Empty");
            }
            yoozBlock = yoozBlock.Trim();

            string specialCharacters = "()\\+-";

            int startIndex = -1;
            int endIndex = yoozBlock.Length;
            bool requestCompleted = false;
            bool requestStarted = false;
            bool notParse = false;
            bool completed = false;
            string response = "";
            string request = "";
            for (int i = 0; i < yoozBlock.Length; i++)
            {
                if (specialCharacters.Contains(yoozBlock[i]))
                {
                    switch (yoozBlock[i])
                    {
                        case ')':
                            if (notParse)
                            {
                                if (!requestCompleted && requestStarted) request += yoozBlock[i];
                                else if(requestStarted) response += yoozBlock[i];
                                notParse = false;
                            }
                            else
                            {
                                startIndex = i;
                                completed = false;
                            }
                            break;
                        case '(':
                            if (notParse)
                            {
                                if (!requestCompleted && requestStarted) request += yoozBlock[i];
                                else if (requestStarted) response += yoozBlock[i];
                                notParse = false;
                            }
                            else
                            {
                                if (!requestCompleted)
                                {
                                    throw new ArgumentException($"{nameof(yoozBlock)} is not in correct format");
                                }
                                endIndex = i;
                                completed = true;
                            }
                            i = yoozBlock.Length;
                            break;
                        case '\\':
                            if (notParse)
                            {
                                if (!requestCompleted && requestStarted) request += yoozBlock[i];
                                else response += yoozBlock[i];
                                notParse = false;
                            }
                            else
                            {
                                notParse = true;
                            }
                            break;
                        case '+':
                            if (notParse)
                            {
                                if (!requestCompleted && requestStarted) request += yoozBlock[i];
                                else response += yoozBlock[i];
                                notParse = false;
                            }
                            else
                            {
                                requestStarted = true;
                            }
                            break;
                        case '-':
                            if (notParse)
                            {
                                if (!requestCompleted && requestStarted) request += yoozBlock[i];
                                else response += yoozBlock[i];
                                notParse = false;

                            }
                            else
                            {
                                requestCompleted = true;
                            }
                            break;
                    }
                }
                else if (!requestCompleted && requestStarted) request += yoozBlock[i];
                else if(requestCompleted) response += yoozBlock[i];
                if (completed)
                {
                    blocks.Add(
                        new YoozBlock(request, response));
                    startIndex = -1;
                    endIndex = yoozBlock.Length;
                    requestCompleted = false;
                    notParse = false;
                    completed = false;
                    response = "";
                    request = "";
                }
            }
            Console.WriteLine("I Am thinking in last part of GetBlock");

            return blocks;
        }
    }
}
