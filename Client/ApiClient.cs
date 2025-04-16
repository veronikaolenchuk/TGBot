using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TGBot.Models;
using TGBot.Response;
using System.Text;
using TGBot.Responce;
using System.Collections.Generic;

namespace TGBot.Client
{
    public class ApiClient
    {
        readonly HttpClient _client;
        private static string _adress;
       
        public ApiClient()
        {
            _adress = config.adress;

            
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adress);
        }



        //---------------------Player---------------------//


        public async Task<PlayerResponce> FindPlayer(string name)
        {
           var response = await _client.GetAsync($"player?name={name}");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            var player = JsonConvert.DeserializeObject<PlayerResponce>(content);
            return player;
        }


        public async Task<PlayerResponceData> ShowPlayer(string User)
        {
            try
            {
                var response = await _client.GetAsync($"DataBase/player?User={User}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var player = JsonConvert.DeserializeObject<PlayerResponceData>(content);
                return player;
            }
            catch(Exception e)
            {
                return null;

            }
        }


        public async Task<Task<string>> SavePlayer(PlayerResponceData player)
        {
            var json = JsonConvert.SerializeObject(player);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var post = await _client.PostAsync($"DataBase/add/player?Name={player.Name}&image={player.image}&User={player.User}", data);
            post.EnsureSuccessStatusCode();
            var postcontent = post.Content.ReadAsStringAsync();
            return postcontent;
        }


        //---------------------Player---------------------//






        //---------------------Team---------------------//


        public async Task<TeamsResponce> FindTeam(string name)
        {
            var response = await _client.GetAsync($"teams?name={name}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var team = JsonConvert.DeserializeObject<TeamsResponce>(content);
            return team;

        }


        public async Task<TeamsResponseData> ShowTeam(string User)
        {
            try
            {
                var response = await _client.GetAsync($"DataBase/team?User={User}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var team = JsonConvert.DeserializeObject<TeamsResponseData>(content);
                return team;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<Task<string>> SaveTeam(TeamsResponseData team)
        {
            var json = JsonConvert.SerializeObject(team);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var post = await _client.PostAsync($"DataBase/add/team?Name={team.Name}&image={team.image}&User={team.User}", data);
            post.EnsureSuccessStatusCode();
            var postcontent = post.Content.ReadAsStringAsync();
            return postcontent;
        }


        //---------------------Team---------------------//







        //---------------------Match---------------------//
        public async Task<List<ListOfMatchResponce>> ListOfMatch()
        {
            var response = await _client.GetAsync($"matches");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
          var matches = JsonConvert.DeserializeObject<List<ListOfMatchResponce>>(content);


            return matches;

        }

        public async Task<ListOfMatchResponce> MatchById(string id)
        {
            var response = await _client.GetAsync($"matches/id?id={id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var matches = JsonConvert.DeserializeObject<ListOfMatchResponce>(content);
            return matches;

        }

        public async Task<MatchResponceData> ShowMatch(string User)
        {
            try
            {
                var response = await _client.GetAsync($"DataBase/match?User={User}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var match = JsonConvert.DeserializeObject<MatchResponceData>(content);
                return match;
            }
            catch (Exception e)
            {
                return null;
            }

        }


        public async Task<Task<string>> SaveMatch(MatchResponceData match)
        {
            var json = JsonConvert.SerializeObject(match);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var post = await _client.PostAsync($"DataBase/add/match?Begin_at={match.Begin_at}&id={match.id}&User={match.User}&Name={match.Name}", data);
            post.EnsureSuccessStatusCode();
            var postcontent = post.Content.ReadAsStringAsync();
            return postcontent;
        }

        //---------------------Match---------------------//







        //---------------------Hero---------------------//


        public async Task<HeroResponce> FindHero(string name)
        {
            var response = await _client.GetAsync($"hero?name={name}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var hero = JsonConvert.DeserializeObject<HeroResponce>(content);
            return hero;

        }
        public async Task<HeroResponceData> ShowHero(string User)
        {
            try
            {
                var response = await _client.GetAsync($"DataBase/hero?User={User}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var hero = JsonConvert.DeserializeObject<HeroResponceData>(content);
                return hero;
            }
            catch(Exception e)
            {
                return null;
            }
        }
          public async Task<Task<string>> SaveHero(HeroResponceData hero)
        {
            var json = JsonConvert.SerializeObject(hero);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var post = await _client.PostAsync($"DataBase/add/hero?Name={hero.name}&image={hero.image}&User={hero.User}&Localized_name={hero.localized_name}", data);
            post.EnsureSuccessStatusCode();
            var postcontent = post.Content.ReadAsStringAsync();
            return postcontent;
        }


        //---------------------Hero---------------------//





    }
}
