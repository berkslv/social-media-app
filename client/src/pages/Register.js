import Logo from "../assets/logo-light.svg";

const Register = () => {
  return (
    <section className="hero has-background-link-light is-fullheight">
      <div className="hero-body">
        <div className="container">
          <div className="columns is-centered">
            <div className="column is-5-tablet is-5-desktop is-4-widescreen">
              <div className="column is-three-quarters mx-auto">
                <img src={Logo} alt="Logo" />
              </div>
              <form action="" className="box">
                <div className="field">
                  <label for="" className="label">
                    İsim
                  </label>
                  <div className="control">
                    <input
                      type="text"
                      placeholder="e.g. Berk Selvi"
                      className="input"
                      required
                    />
                  </div>
                </div>
                <div className="field">
                  <label for="" className="label">
                    Kullanıcı adı
                  </label>
                  <div className="control">
                    <input
                      type="text"
                      placeholder="e.g. Berk Selvi"
                      className="input"
                      required
                    />
                  </div>
                </div>
                <div className="field">
                  <label for="" className="label">
                    Email
                  </label>
                  <div className="control">
                    <input
                      type="email"
                      placeholder="e.g. bobsmith@gmail.com"
                      className="input"
                      required
                    />
                  </div>
                </div>
                <div className="field">
                  <label for="" className="label">
                    Parola
                  </label>
                  <div className="control">
                    <input
                      type="password"
                      placeholder="*******"
                      className="input"
                      required
                    />
                  </div>
                </div>
                <div className="field">
                  <label for="" className="label">
                    Parola (tekrar giriniz)
                  </label>
                  <div className="control">
                    <input
                      type="password"
                      placeholder="*******"
                      className="input"
                      required
                    />
                  </div>
                </div>
                <div className="field mt-3">
                  <button className="button is-success is-fullwidth">
                    Kayıt ol
                  </button>
                </div>
                <div className="field mt-3">
                  <button className="button has-background-success-light has-text-success is-fullwidth">
                    Kayıt olmadan devam et
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default Register;
