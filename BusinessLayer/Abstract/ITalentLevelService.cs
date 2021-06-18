using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentLevelService
    {
        List<TalentLevel> GetList();
        TalentLevel GetByID(int id);
        void Add(TalentLevel talentLevel );
        void Update(TalentLevel talentLevel );
        void Delete(TalentLevel talentLevel );
    }
}
