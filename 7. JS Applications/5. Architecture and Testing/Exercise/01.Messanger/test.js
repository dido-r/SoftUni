const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

let browser, page;

describe('Accordion-Testing', async function () {

    before(async () => { browser = await chromium.launch(); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    it('Load messages', async function () {

        await page.goto('http://127.0.0.1:5500/');
        await page.click('#refresh');
        let messages = await page.textContent('#messages');
        expect(messages).to.contain('Spami: Hello, are you there?\nGarry: Yep, whats up :?\nSpami: How are you? Long time no see? :)\nGeorge: Hello, guys! :))\nSpami: Hello, George nice to see you! :)))');
    });

    it('Send messages', async function () {

        await page.goto('http://127.0.0.1:5500/');
        await page.fill('[name="author"]', 'Me');
        await page.fill('[name="content"]', 'New message');
        await page.click('#submit');
        let res = await page.waitForResponse('http://localhost:3030/jsonstore/messenger');
        const data = await JSON.parse(res.request().postData())
        expect(data.author).to.equal('Me');
        expect(data.content).to.equal('New message');
    });

});