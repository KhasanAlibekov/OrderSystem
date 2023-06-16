﻿using Microsoft.EntityFrameworkCore;
using Ordersystem.DataAccess;
using Ordersystem.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.Services
{
    public interface IMessageService
    {
        List<Message> GetAllMessages();
        Message? GetMessageByID(int id);
        Message Create(Message message);
        Message Update(int id, Message message);
        bool Delete(int id);
    }

    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        public MessageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }

        public Message? GetMessageByID(int id)
        {
            return _context.Messages.Where(c => c.MessageID == id).FirstOrDefault();
        }

        public Message Create(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }

        public Message Update(int id, Message newMessage)
        {
            var messageToUpdate = _context.Messages.Where(c => c.MessageID == id).FirstOrDefault();

            if (messageToUpdate != null)
            {
                // Update only properties that were changed
                messageToUpdate.Title= newMessage.Title;
                messageToUpdate.Content = newMessage.Content;
                messageToUpdate.Date = newMessage.Date;

                _context.Update(messageToUpdate);
                _context.SaveChanges();

                return messageToUpdate;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var result = _context.Messages.ToList().FirstOrDefault(c => c.MessageID == id, null);
            if (result != null)
            {
                _context.Messages.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}