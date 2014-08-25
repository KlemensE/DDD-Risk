﻿namespace Core.InvitationPhase.Handlers
{
    using System;

    using CommonDomain.Persistence;

    using Core.Infrastructure;

    public class StartGameHandler : ICommandHandler<StartGame>
    {
        private readonly IRepository _repository;

        public StartGameHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(StartGame command)
        {
            var lobby = _repository.GetById<Lobby>(command.LobbyId);
            lobby.StartGame();
            _repository.Save(lobby, Guid.NewGuid());
        }
    }
}
