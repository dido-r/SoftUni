const { chromium } = require('playwright-chromium');
const { expect, assert } = require('chai');

let browser, page;

describe('Accordion-Testing', async function () {

    before(async () => { browser = await chromium.launch(); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    it('Load books', async function () {

        await page.goto('http://127.0.0.1:5500/');
        await page.click('#loadBooks');
        let text = await page.textContent('tbody');
        expect(text).to.contain("Harry Potter and the Philosopher's Stone");
        expect(text).to.contain('J.K.Rowling');
        expect(text).to.contain('C# Fundamentals');
        expect(text).to.contain('Svetlin Nakov');
    });

    it('Add books', async function () {

        await page.goto('http://127.0.0.1:5500/');
        await page.fill('[name="title"]', 'Necronomicon');
        await page.fill('[name="author"]', 'H.P. Lovecraft');
        await page.click('text=Submit');
        let response = await page.waitForResponse('http://localhost:3030/jsonstore/collections/books');
        let data = await JSON.parse(response.request().postData())
        expect(data.title).to.equal("Necronomicon");
        expect(data.author).to.equal("H.P. Lovecraft");
    });

    it('Add empty fields books', async function () {

        await page.goto('http://127.0.0.1:5500/');
        await page.fill('[name="title"]', '');
        await page.fill('[name="author"]', 'Ivalid input');
        await page.click('text=Submit');
        await page.click('#loadBooks');
        let text = await page.textContent('tbody');
        expect(text).to.not.contain("Ivalid input");
    });

    it('Edit books check form labels', async function () {

        await page.goto('http://127.0.0.1:5500/');
        await page.click('#loadBooks');
        await page.click('[id="b6f035ef-d5d9-4dcd-aafc-f230e54f522b"] button', { hasText: 'Edit' });
        let formTitle = await page.textContent('form>h3');
        let saveButton = await page.isVisible('text=Save');
        let submitButton = await page.isVisible('text=Submit');
        expect(formTitle).to.equal("Edit Form");
        expect(saveButton).to.be.true;
        expect(submitButton).to.be.false;
    });

    it('Edit books check request', async function () {

        await page.goto('http://127.0.0.1:5500/');
        await page.click('#loadBooks');
        await page.click('[id="b6f035ef-d5d9-4dcd-aafc-f230e54f522b"] button', { hasText: 'Edit' });
        await page.fill('[name="title"]', 'Mountains of madness');
        const [response] = await Promise.all([
            page.waitForResponse('http://localhost:3030/jsonstore/collections/books/b6f035ef-d5d9-4dcd-aafc-f230e54f522b'),
            page.click('text=Save'),
        ]);
        let data = await JSON.parse(response.request().postData());
        expect(data.title).to.equal("Mountains of madness");
        expect(data.author).to.equal("H.P. Lovecraft");
    });

     it('Edit books input value', async function () {

         await page.goto('http://127.0.0.1:5500/');
         await page.click('#loadBooks');
         await page.click('[id="b6f035ef-d5d9-4dcd-aafc-f230e54f522b"] button', { hasText: 'Edit' });
         let title = await page.$eval('[name="title"]', el => el.value);
         let author = await page.$eval('[name="author"]', el => el.value);
         expect(title).to.equal("LOTR");
         expect(author).to.equal("Tolkien");
     });

    it('Delete book', async function () {

        await page.goto('http://127.0.0.1:5500/');
        await page.click('#loadBooks');
        let deleted = await page.textContent('tbody tr>td');
        await page.click('tbody tr >> text=Delete');
        let text = await page.textContent('tbody');
        expect(text).to.not.contain(deleted);
    });
});