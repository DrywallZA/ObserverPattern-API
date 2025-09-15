using ObserverPatternAPI.Database;
using ObserverPatternAPI.Interfaces;
using ObserverPatternAPI.Models.PokeModel;

namespace ObserverPatternAPI.Observers
{
    public class SquirtleObserver : IObserver
    {
        private readonly IPokeObservable _pokeObservable;
        private string _squirtleType = "Water";

        public SquirtleObserver(IPokeObservable pokeObservable)
        {
            //If for some reason you need to remove the registation to a Observable then it will be done on the Observer
            _pokeObservable = pokeObservable;
            _pokeObservable.RegisterObserver(this);
        }

        public void Update(List<string> pokemonData)
        {
            var pokeStorage = new PokeStorage();
            var pokeModel = new PokeModel();

            foreach (var pokemon in pokemonData)
            {
                if (pokemon.ToLower().Contains("squirtle"))
                {
                    pokeModel.Name = pokemon;
                    pokeModel.Type = _squirtleType;
                    pokeStorage.SavePokemon(pokeModel);
                }
            }
        }
    }
}