using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private ICollection<HttpCookie> cookieList;

        public HttpCookieCollection()
        {
            this.cookieList = new List<HttpCookie>();
        }


        public ICollection<HttpCookie> CookieList => this.cookieList;

        public void AddCookie(HttpCookie cookie)
        {
            cookieList.Add(cookie);
        }

        public bool ContainsCookie(string key)
        {
            var tempCookie = cookieList.FirstOrDefault(x => x.Key == key);

            if (tempCookie is null)
            {
                return false;
            }

            return true;
        }

        public HttpCookie GetCookie(string key)
        {
            var targetCookie = cookieList.FirstOrDefault(x => x.Key == key);

            return targetCookie;
        }

        public bool HasCookies()
        {
            if (cookieList.Any())
            {
                return true;
            }

            return false;
        }

        //public override string ToString()
        //{
        //   return string.Join(HttpCookieStringSeparator, this.cookies.Values);
        //}
    }
}
