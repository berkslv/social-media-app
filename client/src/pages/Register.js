import Logo from "../assets/logo-light.svg";

const Register = () => {
  return (
    <section class="hero has-background-link-light is-fullheight">
      <div class="hero-body">
        <div class="container">
          <div class="columns is-centered">
            <div class="column is-5-tablet is-5-desktop is-4-widescreen">
              <div class="column is-three-quarters mx-auto">
                <img src={Logo} alt="Logo" />
              </div>
              <form action="" class="box">
                <div class="field">
                  <label for="" class="label">
                    İsim
                  </label>
                  <div class="control">
                    <input
                      type="text"
                      placeholder="e.g. Berk Selvi"
                      class="input"
                      required
                    />
                  </div>
                </div>
                <div class="field">
                  <label for="" class="label">
                    Kullanıcı adı
                  </label>
                  <div class="control">
                    <input
                      type="text"
                      placeholder="e.g. Berk Selvi"
                      class="input"
                      required
                    />
                  </div>
                </div>
                <div class="field">
                  <label for="" class="label">
                    Email
                  </label>
                  <div class="control">
                    <input
                      type="email"
                      placeholder="e.g. bobsmith@gmail.com"
                      class="input"
                      required
                    />
                  </div>
                </div>
                <div class="field">
                  <label for="" class="label">
                    Parola
                  </label>
                  <div class="control">
                    <input
                      type="password"
                      placeholder="*******"
                      class="input"
                      required
                    />
                  </div>
                </div>
                <div class="field">
                  <label for="" class="label">
                    Parola (tekrar giriniz)
                  </label>
                  <div class="control">
                    <input
                      type="password"
                      placeholder="*******"
                      class="input"
                      required
                    />
                  </div>
                </div>
                <div class="field mt-3">
                  <button class="button is-success is-fullwidth">
                    Giriş yap
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
