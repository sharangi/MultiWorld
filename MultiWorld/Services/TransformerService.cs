using MultiWorld.DAL;
using MultiWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiWorld.Services
{
    public interface ITransformerService
    {
        Transformer GetTransformerById(Guid id);
        IEnumerable<Transformer> GetAllAutobots();
        IEnumerable<Transformer> GetAllDecepticons();
        void Add(Transformer transformer);
        void Update(Transformer transformer);
        void Remove(Transformer transformer);
    }
    public class TransformerService : ITransformerService
    {
        private readonly ITransformerRepository _transformerRepository;
        public TransformerService(ITransformerRepository transformerRepository)
        {
            _transformerRepository = transformerRepository;
        }

        public Transformer GetTransformerById(Guid id)
        {
            return _transformerRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }
        public IEnumerable<Transformer> GetAllAutobots()
        {
            return _transformerRepository.GetAll().Where(p => p.Allegiance == AllegianceType.Autobot).OrderBy(p => p.Name);
        }
        public IEnumerable<Transformer> GetAllDecepticons()
        {
            return _transformerRepository.GetAll().Where(p => p.Allegiance == AllegianceType.Decepticon).OrderBy(p => p.Name);
        }
        public void Add(Transformer transformer)
        {
            _transformerRepository.Add(transformer);
            _transformerRepository.Commit();
        }
        public void Update(Transformer transformer)
        {
            _transformerRepository.Update(transformer);
            _transformerRepository.Commit();
        }
        public void Remove(Transformer transformer)
        {
            _transformerRepository.Delete(transformer);
            _transformerRepository.Commit();
        }
    }
}
