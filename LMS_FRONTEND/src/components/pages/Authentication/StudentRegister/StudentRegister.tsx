import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { Link } from "react-router-dom";

//FormSchema and Validation
const FormSchema = z.object({
  email: z.string().min(6, {
    message: "Email must have more than 6 characters", //This will be shown using FormMessage
  }),
  password: z
    .string()
    .min(6, { message: "Password must have more than 6 characters" }),
  fullname: z
    .string()
    .min(3, { message: "Fullname must have more than 3 characters" }),
  supervisor: z.number(),
});

//LoginForm component
const RegisterForm: React.FC = () => {
  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      email: "",
      password: "",
    },
  });

  //onSubmit
  function onSubmit(data: z.infer<typeof FormSchema>) {
    console.log(data);
    //Submit Logic
  }

  //HTML?
  return (
    <div className="loginFormContainer">
      <Card className="card">
        <CardHeader>
          <CardTitle>Register</CardTitle>
          <CardDescription>
            Welcome to SAP Lab Management System
          </CardDescription>
        </CardHeader>
        <CardContent className="card-content">
          <Form {...form}>
            <form
              onSubmit={form.handleSubmit(onSubmit)}
              className="w-2/3 space-y-6"
            >
              {/* Email or Roll Number Input Field */}
              <FormField
                control={form.control}
                name="emailOrRoll"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Email Or Roll Number</FormLabel>
                    <FormControl>
                      <Input
                        placeholder="yourname@fpt.edu.vn/HE123456"
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              {/* Password Input Field */}
              <FormField
                control={form.control}
                name="password"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Password</FormLabel>
                    <FormControl>
                      <Input
                        placeholder="Password must have more than 6 characters"
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <Button type="submit">Submit</Button>
            </form>
          </Form>
        </CardContent>
        <CardFooter>
          <p>
            Don't have an account?{" "}
            <Link className="registerLink" to={"/StudentRegister"}>
              Register now
            </Link>
          </p>
        </CardFooter>
      </Card>{" "}
    </div>
  );
};

export default RegisterForm;
