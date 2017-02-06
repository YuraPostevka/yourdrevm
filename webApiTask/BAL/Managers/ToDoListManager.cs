using BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.Interfaces;
using Models.DTO;
using AutoMapper;

namespace BAL.Managers
{
    public class ToDoListManager : BaseManager, IToDoListManager
    {
        public ToDoListManager(IUnitOfWork uOW)
            : base(uOW) { }

        /// <summary>
        /// Delete todo list
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int? id)
        {
            if (id == null) return;
            try
            {
                var item = new ToDoList() { Id = id.Value };
                uOW.ToDoListRepo.Delete(item);
                uOW.Save();
            }
            catch { }
        }

        /// <summary>
        /// Get all todo lists
        /// </summary>
        /// <returns></returns>
        public List<ListTagDTO> GetAll()
        {
            var result = new List<ListTagDTO>();
            List<ToDoList> toDoLists = uOW.ToDoListRepo.Get(includeProperties: "Items").ToList();

            foreach (var list in toDoLists)
            {
                var listTag = Mapper.Map<ListTagDTO>(list);

                //get ids of tags with list
                var ids = uOW.ToDoListsTagsRepo.All.Where(i => i.ToDoListId == list.Id).Select(i => i.TagId).ToList();
                //get tags with list
                var tags = uOW.TagRepo.All.Where(m => ids.Contains(m.Id)).ToList();

                listTag.Tags.AddRange(tags);

                result.Add(listTag);
            }
            return result;
        }

        /// <summary>
        /// Get todo list by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ToDoList GetById(int? id)
        {
            if (id == null) return null;
            return uOW.ToDoListRepo.GetByID(id);
        }

        /// <summary>
        /// Insert todo list
        /// </summary>
        /// <param name="item"></param>
        public ListTagDTO Insert(ToDoList item)
        {

            if (item == null) return null;

            uOW.ToDoListRepo.Insert(item);
            uOW.Save();

            var mappedItem = Mapper.Map<ListTagDTO>(item);
            return mappedItem;
        }

        /// <summary>
        /// Update todo list
        /// </summary>
        /// <param name="item"></param>
        public void ChangeName(int id, string name)
        {
            var dbItem = uOW.ToDoListRepo.GetByID(id);
            dbItem.Name = name;

            uOW.Save();
        }
    }
}
