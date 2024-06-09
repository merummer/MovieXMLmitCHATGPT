using MovieXMLmitCHATGPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieXMLmitCHATGPT.Repositories
{
    public class MovieRepository
    {
        private XElement _rootElement;
        private string _filepath;
        public MovieRepository(string filepath)
        {
            _filepath = filepath;
            if (File.Exists(filepath))
            {
                this._rootElement = XElement.Load(filepath);
            }
            else
            {
                this._rootElement = new XElement("movies");
            }
        }

        public List<Movie> GetAll()
        {
            return this._rootElement.Descendants("movie").Select(
                x => new Movie
                {
                    Id = (int)x.Attribute("id"),
                    Title = (string)x.Attribute("title"),
                    Director = (string)x.Attribute("director"),
                    Year = (int)x.Attribute("year")
                }).ToList();
            
        }

        public Movie GetById(int id)
        {
            XElement movieelement =  this._rootElement.Descendants("movie").FirstOrDefault(x => (int)x.Attribute("id") == id);
            if (movieelement != null)
            {
                return new Movie
                {
                    Id = (int)movieelement.Attribute("id"),
                    Title = (string)movieelement.Attribute("title"),
                    Director = (string)movieelement.Attribute("director"),
                    Year = (int)movieelement.Attribute("year")
                };
            }
            return null;
        }

        public void Add(Movie movie)
        {
            var item = new XElement("movie");
            item.Add(new XAttribute("id", movie.Id.ToString()));
            item.Add(new XAttribute("title", movie.Title));
            item.Add(new XAttribute("director",movie.Director));
            item.Add(new XAttribute("year",movie.Year.ToString()));

            this._rootElement.Add(item);
            this._rootElement.Save(_filepath);
        }

        public void Update(Movie movie)
        {
            XElement item = this._rootElement.Descendants("movie").FirstOrDefault(x => (int)x.Attribute("id") == movie.Id);
            if (item != null)
            {
                item.Attribute("title").Value = movie.Title;
                item.Attribute("director").Value = movie.Director;
                item.Attribute("year").Value = movie.Year.ToString();
                this._rootElement.Save(_filepath);
            }
        }

        public void Delete(int id)
        {
            XElement item = this._rootElement.Descendants("movie").FirstOrDefault(x => (int)x.Attribute("id") == id);

            if (item != null)
            {
                item.Remove();
                this._rootElement.Save(_filepath);
            }
        }
    }
}
