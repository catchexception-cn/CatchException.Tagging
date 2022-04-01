import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Tagging',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44368',
    redirectUri: baseUrl,
    clientId: 'Tagging_App',
    responseType: 'code',
    scope: 'offline_access Tagging role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44368',
      rootNamespace: 'CatchException.Tagging',
    },
    Tagging: {
      url: 'https://localhost:44362',
      rootNamespace: 'CatchException.Tagging',
    },
  },
} as Environment;
