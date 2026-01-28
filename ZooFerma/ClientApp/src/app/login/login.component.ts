import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ConnectionInfos } from '../../models/connection.infos';
import { SessionService } from '../../services/session.service';

@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html',
  providers: [MessageService, SessionService]
})
export class LoginComponent implements OnInit {

  version: string = "";
  connectionInfo: ConnectionInfos;
  loading = false;

  constructor(private router: Router,
    private messageService: MessageService,
    private sessionService: SessionService)
  {
    this.connectionInfo = new ConnectionInfos();
  }

  ngOnInit()
  {
    this.loadDbVersion();
  }

  loadDbVersion() {
    this.sessionService.getDbVersion().subscribe({
      next: (version) => this.version = version,
      error: () => this.version = 'Ошибка загрузки'
    });
  }

  openConnection() {
    this.loading = true;
    this.sessionService.openConnection().subscribe({
      next: (data) => {
        this.connectionInfo = data;
        this.loading = false;
        this.messageService.add({
          severity: 'success',
          summary: 'Успех',
          detail: 'Соединение установлено'
        });
      },
      error: (error) => {
        this.loading = false;
        this.messageService.add({
          severity: 'error',
          summary: 'Ошибка',
          detail: 'Не удалось открыть соединение'
        });
        console.error('Open connection error:', error);
      }
    });
  }

  closeConnection() {
    this.loading = true;
    this.sessionService.closeConnection().subscribe({
      next: (data) => {
        this.connectionInfo = data;
        this.loading = false;
        this.messageService.add({
          severity: 'warn',
          summary: 'Соединение закрыто',
          detail: 'Подключение к БД разорвано'
        });
      },
      error: (error) => {
        this.loading = false;
        this.messageService.add({
          severity: 'error',
          summary: 'Ошибка',
          detail: 'Не удалось закрыть соединение'
        });
        console.error('Close connection error:', error);
      }
    });
  }
}
