using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Repositories
{
    public class ButtonClickUnitOfWork : UnitOfWork<ButtonClicksCounterContext>, IButtonClickUnitOfWork
    {
        private readonly IButtonClickRepository _repository;
        public ButtonClickUnitOfWork(ButtonClicksCounterContext context, ILog logger)
            : base(context, logger)
        {
            RegisterRepositoryTypes<ButtonClicksCounter>(typeof(ButtonClickRepository));

            _repository = (IButtonClickRepository)GetRepository<ButtonClicksCounter>();
        }


        public void Create(ButtonClicksCounter item)
        {
            _repository.Create(item);
        }

        public async Task<ButtonClicksCounter> GetByIdAsync(object id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Update(ButtonClicksCounter item)
        {
            _repository.Update(item);
        }
    }
}