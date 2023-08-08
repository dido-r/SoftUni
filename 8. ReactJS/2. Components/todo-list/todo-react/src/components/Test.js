import { useState } from "react";
import { CreatePost } from "../CreatePost/CreatePost";
import { Banner } from "./Banner/Banner";

export function Profile() {

    const [tag, setTag] = useState('post');

    const renderSwitch = (tag) => {
        switch (tag) {
            case 'profile':
                return <Posts />;
            case 'photos':
                return <Photos />;
        }
    }

    return (
        <>
            <div className={styles['collection-hero']}>
            <div className={styles['img-container']}>
                <img className={styles['collection-hero-image']} src="https://scontent-otp1-1.xx.fbcdn.net/v/t1.6435-9/124888021_3930312033664001_1886930670957451531_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=e3f864&_nc_ohc=FzS5i5xtj_QAX_bYdpb&_nc_ht=scontent-otp1-1.xx&oh=00_AfBqO-GbETHOBmR_bb37BJKwyItWFOVHx8pS5NtfdgyRoQ&oe=649DCE67" alt="" />
                <img className={styles['profile-img']} src="https://cdn-icons-png.flaticon.com/512/149/149071.png" alt="img" />
                <h2 className={styles['pofile-username']}>Username</h2>
                <hr className={styles['pofile-hr']} />
                <ul className={styles['pofile-ul']}>
                <div className="bg-dark bg-gradient">
                <img className="card-img-top" src="https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg" alt="img" />

                <div className="card-body">
                    <h5 className="text-light">Username</h5>
                </div>
            </div>

            <div className="bg-dark bg-gradient">
                <img className="card-img-top" src="https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg" alt="img" />

                <div className="card-body">
                    <h5 className="text-light">Username</h5>
                </div>
            </div>

            <div className="bg-dark bg-gradient">
                <img className="card-img-top" src="https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg" alt="img" />

                <div className="card-body">
                    <h5 className="text-light">Username</h5>
                </div>
            </div>

            <div className="bg-dark bg-gradient">
                <img className="card-img-top" src="https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg" alt="img" />

                <div className="card-body">
                    <h5 className="text-light">Username</h5>
                </div>
            </div>

            <div className="bg-dark bg-gradient">
                <img className="card-img-top" src="https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg" alt="img" />

                <div className="card-body">
                    <h5 className="text-light">Username</h5>
                </div>
            </div>

            <div className="bg-dark bg-gradient">
                <img className="card-img-top" src="https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg" alt="img" />

                <div className="card-body">
                    <h5 className="text-light">Username</h5>
                </div>
            </div>

            <div className="bg-dark bg-gradient">
                <img className="card-img-top" src="https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg" alt="img" />

                <div className="card-body">
                    <h5 className="text-light">Username</h5>
                </div>
            </div>

            <div className="bg-dark bg-gradient">
                <img className="card-img-top" src="https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg" alt="img" />

                <div className="card-body">
                    <h5 className="text-light">Username</h5>
                </div>
            </div>

            <div className="bg-dark bg-gradient">
                <img className="card-img-top" src="https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg" alt="img" />

                <div className="card-body">
                    <h5 className="text-light">Username</h5>
                </div>
            </div>
                </ul>
            </div>
        </div>
        </>
    );
}