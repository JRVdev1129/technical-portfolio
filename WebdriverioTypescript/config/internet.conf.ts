import { commonConf } from "./common.conf.ts";

const mainConf = {
  capabilities: [
    {
      browserName: "chrome",
      browserVersion: "stable",
      maxInstances: 1,
      pageLoadStrategy: "eager",
      "goog:chromeOptions": {
        args: [
          //   'headless',
          "no-sandbox",
          "disable-infobars",
          "disable-gpu",
          "disable-extension",
          "disable-dev-shm-usage",
          "disable-gpu",
          "window-size=1440,1280",
        ],
      },
    },
  ],
  specs: ["../test/specs/**/**.spec.ts"],
  suites: {
    heroku: ["../test/specs/internet/test.e2e.ts"],
  },
  waitforTimeout: 120000,
  connectionRetryCount: 3,
  connectionRetryTimeout: 600000,
};

const config = Object.assign({}, commonConf, mainConf);

export { config };
