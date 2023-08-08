import { del } from "../api.js";

export async function deleteItem(ctx) {

    let id = ctx.params.id;

    try {

        await del(`data/catalog/${id}`, undefined, true);
        window.location.href = "/";

    } catch (err) {

        alert(err.message)
        return;
    }
}