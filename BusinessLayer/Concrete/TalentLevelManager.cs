using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TalentLevelManager : ITalentLevelService
    {
        ITalentLevelDal _talentLevelDal;

        public TalentLevelManager(ITalentLevelDal talentLevelDal)
        {
            _talentLevelDal = talentLevelDal;
        }

        public void Add(TalentLevel talentLevel)
        {
            _talentLevelDal.Insert(talentLevel);
        }

        public void Delete(TalentLevel talentLevel)
        {
            _talentLevelDal.Delete(talentLevel);
        }

        public TalentLevel GetByID(int id)
        {
            return _talentLevelDal.Get(x => x.SkillId == id);
        }

        public List<TalentLevel> GetList()
        {
            return _talentLevelDal.List();
        }

        public void Update(TalentLevel talentLevel)
        {
            _talentLevelDal.Update(talentLevel);
        }
    }
}
