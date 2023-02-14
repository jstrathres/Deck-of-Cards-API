using Newtonsoft.Json;
using System.Net;

namespace DECK_OF_CARDS_API.Models
{
    public class DeckOfCardsDAL
    {
        public static CardModel GetCards() 
        {
            //Will need to adjust URL
            //SetUp -copy link
            string key = "vxa7mc4t575x";           
            string url = $"https://deckofcardsapi.com/api/deck/{key}/draw/?count=5";


            //request -pulls from url(above), saves. 
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            //Convert to JSON.  Streamreader, then converts to JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();


            //Adjust Names to match class naem
            //Convert to C#. Pass JSON in
            CardModel result = JsonConvert.DeserializeObject<CardModel>(JSON);
            return result;
        }
        public static void ShuffleCards()
        {
            //setup from Shuffle link, same code
            string key = "vxa7mc4t575x";
            string url = $"https://deckofcardsapi.com/api/deck/{key}/shuffle/";

            //request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        
        }
    }
}
