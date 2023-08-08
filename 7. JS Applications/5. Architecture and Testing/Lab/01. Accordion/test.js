const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

let browser, page;

describe('Accordion-Testing', async function () {

    before(async () => { browser = await chromium.launch(); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    it('Check title', async function() {

        await page.goto('http://127.0.0.1:5500/');
        await page.waitForSelector('#main');
        let title = await page.textContent('#main');
        expect(title).to.contain('Scalable Vector Graphics');
        expect(title).to.contain('Open standard');
        expect(title).to.contain('Unix');
        expect(title).to.contain('ALGOL');
    });

    it('Button More functionality', async function() {


        await page.goto('http://127.0.0.1:5500/');
        await page.click('button');
        await page.waitForSelector('.extra p');
        let buttonName = await page.textContent('button');
        let title = await page.isVisible('.extra p');
        expect(title).to.be.true;
        expect(buttonName).to.be.equal('Less');
    });

    it('Button Less functionality', async function() {

        
        await page.goto('http://127.0.0.1:5500/');
        await page.click('button');
        await page.click('button');
        let buttonName = await page.textContent('button');
        let title = await page.isVisible('.extra p');
        expect(title).to.be.false;
        expect(buttonName).to.be.equal('More');
    });
});